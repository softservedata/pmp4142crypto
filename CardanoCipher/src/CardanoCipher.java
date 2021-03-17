import javafx.util.Pair;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Random;

public class CardanoCipher {
    String chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
    Random random;
    static final int N = 4;

    char[][] inputMatrix = new char[N][N];
    char[][] rotate90 = new char[N][N];
    char[][] rotate180 = new char[N][N];
    char[][] rotate270 = new char[N][N];
    char[][] keyMatrix = new char[N][N];

    public String encrypt(String text, int[] arr){
        random = new Random();
        String res = "";
        int temp = 0;
        inputMatrix = getKeys(arr).get(0);
        rotate90 = getKeys(arr).get(1);
        rotate180 = getKeys(arr).get(2);
        rotate270 = getKeys(arr).get(3);
        keyMatrix = getKeys(arr).get(4);

        char[][] matrixEncrypted = new char[N][N];
        while(temp < text.length()){
            Pair<Integer, char[][]> inputPair = matrixUpdateEncipher(matrixEncrypted, inputMatrix, text, temp);
            temp = inputPair.getKey();
            matrixEncrypted = inputPair.getValue();

            Pair<Integer, char[][]> rotate90Pair = matrixUpdateEncipher(matrixEncrypted, rotate90, text, temp);
            temp = rotate90Pair.getKey();
            matrixEncrypted = rotate90Pair.getValue();

            Pair<Integer, char[][]> rotate180Pair = matrixUpdateEncipher(matrixEncrypted, rotate180, text, temp);
            temp = rotate180Pair.getKey();
            matrixEncrypted = rotate180Pair.getValue();

            Pair<Integer, char[][]> rotate270Pair = matrixUpdateEncipher(matrixEncrypted, rotate270, text, temp);
            temp = rotate270Pair.getKey();
            matrixEncrypted = rotate270Pair.getValue();

            for (int i =0; i<N; i++){
                for(int j = 0; j<N; j++){
                    if(matrixEncrypted[i][j] == '\0'){
                        matrixEncrypted[i][j] = getRandomCharacter(chars, random);
                    }
                }
            }


            for (int i =0; i<N; i++){
                for(int j = 0; j<N; j++){
                    res += matrixEncrypted[i][j];
                }
            }

            for (int i = 0; i < N; i++) {
                for (int j = 0; j < N; j++) {
                    matrixEncrypted[i][j] = '\0';
                }
            }
        }
        return res;
    }

    public String decrypt(String text, int arr[]){
        String res = "";
        int temp = 0;
        char[][] matrixEncrypted = new char[N][N];
        //printMatrix(inputMatrix);
        while(temp < text.length()){
            for(int i =0; i<N; i++){
                for(int j =0; j<N; j++){
                    matrixEncrypted[i][j] = text.charAt(temp);
                    temp++;
                }
            }
            res = messageUpdateDecipher(matrixEncrypted, inputMatrix, res);
            res = messageUpdateDecipher(matrixEncrypted, rotate90, res);
            res = messageUpdateDecipher(matrixEncrypted, rotate180, res);
            res = messageUpdateDecipher(matrixEncrypted, rotate270, res);
        }
        return res;
    }

    public char[][] rotate90Clockwise(char[][] a){
        char[][] arr = new char[N][N];
        for (int i = 0; i<N/2; i++){
            for(int j =i; j<N-i-1;j++){
                char temp = a[i][j];
                arr[i][j] = a[N - 1 - j][i];
                arr[N - 1 - j][i] = a[N - 1 - i][N - 1 - j];
                arr[N - 1 - i][N - 1 - j] = a[j][N - 1 - i];
                arr[j][N - 1 - i] = temp;
            }
        }
        return arr;
    }

    public Map<Integer, char[][]> getKeys(int[] arr){
        char[][] inputMatrix = new char[N][N];
        for (int i =0; i<N; i++){
            char[] tempArr = padLeftZeros(Integer.toBinaryString(arr[i]), 4).toCharArray();
            for (int j = 0; j<N; j++){
                inputMatrix[i][j] = tempArr[j];
            }
        }
        char[][] rotate90 = rotate90Clockwise(inputMatrix);
        char[][] rotate180 = rotate90Clockwise(rotate90);
        char[][] rotate270 = rotate90Clockwise(rotate180);

        char[][]key = new char[N][N];
        for (int i = 0; i<N; i++){
            for(int j = 0; j<N; j++){
                if(inputMatrix[i][j] == '1'|| rotate90[i][j] == '1' || rotate180[i][j] == '1' || rotate270[i][j] == '1'){
                    key[i][j] = '1';
                }
                else{
                    key[i][j] = 'R';
                }
            }
        }

        Map<Integer,char[][]> map = new HashMap<Integer,char[][]>();
        map.put(0, inputMatrix);
        map.put(1, rotate90);
        map.put(2, rotate180);
        map.put(3,rotate270);
        map.put(4, key);

        return map;
    }

    public String padLeftZeros(String inputString, int length) {
        if (inputString.length() >= length) {
            return inputString;
        }
        StringBuilder sb = new StringBuilder();
        while (sb.length() < length - inputString.length()) {
            sb.append('0');
        }
        sb.append(inputString);

        return sb.toString();
    }

    public Pair<Integer, char[][]> matrixUpdateEncipher(char[][] matr, char[][] key, String inputText, int temp){
        for (int i = 0; i<N; i++){
            for(int j = 0; j<N; j++){
                if (key[i][j] == '1'){
                    if(temp < inputText.length()){
                        matr[i][j] = inputText.charAt(temp);
                        temp++;
                    }
                    else{
                        matr[i][j] = getRandomCharacter(chars, random);
                    }
                }
            }
        }
        return new Pair<Integer,char[][]>(temp, matr);
    }

    public String messageUpdateDecipher(char[][]matr, char[][]key, String resText){
        for(int i = 0; i<N; i++){
            for(int j = 0; j<N; j++){
                if(key[i][j] == '1'){
                    resText += matr[i][j];
                    //System.out.println(matr[i][j]);
                }
            }
        }
        return resText;
    }

    public char getRandomCharacter(String text, Random rng) {
        int index =rng.nextInt(text.length());
        return text.charAt(index);
    }

    public void printMatrix(char[][] a){
        for (int i = 0; i<N; i++){
            for(int j =0; j<N; j++){
                System.out.println(a[i][j] + " ");
            }
            System.out.println("\n");
        }

    }

}
