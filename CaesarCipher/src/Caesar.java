import java.io.*;
import java.net.URISyntaxException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Scanner;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class Caesar {
    public static String encrypt(String text, int shift){
        StringBuilder result = new StringBuilder();
        if (shift>26){
           shift = shift % 26;
       }
       else if(shift < 0) {
           shift = (shift % 26) + 26;
       }
        for (int i =0; i< text.length(); i++){
            if((int)text.charAt(i)== 32){
                result.append(text.charAt(i));
            }
            else {
                if (Character.isUpperCase(text.charAt(i))) {
                    char ch = (char) (((int) text.charAt(i) +
                            shift - 65) % 26 + 65);
                    result.append(ch);

                } else {
                    char ch = (char) (((int) text.charAt(i) +
                            shift - 97) % 26 + 97);
                    result.append(ch);
                }
            }
        }
        return result.toString();
    }
    public static String decrypt(String text, int shift){
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < text.length(); i++) {
            if ((int) text.charAt(i) == 32) {
                result.append(text.charAt(i));
            } else {
                if (Character.isUpperCase(text.charAt(i))) {
                    char ch = (char) (((int) text.charAt(i) +
                            shift - 65) % 26 + 65);
                    result.append(ch);
                } else {
                    char ch = (char) (((int) text.charAt(i) +
                            shift - 97) % 26 + 97);
                    result.append(ch);
                }
            }
        }
        return result.toString();
    }
    public static void main(String[] args) throws IOException, URISyntaxException {

        String file ="plain.txt";
        String text = null;

        DataInputStream reader = new DataInputStream(new FileInputStream(file));
        int nBytesToRead = reader.available();
        if(nBytesToRead > 0) {
            byte[] bytes = new byte[nBytesToRead];
            reader.read(bytes);
            text = new String(bytes);
        }
        System.out.println(text);
        Scanner in = new Scanner(System.in);
        System.out.println("Enter shift: ");
        int shift = in.nextInt();
        String encryptedText  = encrypt(text, shift);
        System.out.println("Writing to a file....");
        BufferedWriter writer = new BufferedWriter(new FileWriter("encrypt.txt"));
        writer.write(encryptedText);
        writer.close();

        String decrypted = decrypt(encryptedText,26 - shift);
        BufferedWriter write = new BufferedWriter(new FileWriter("decrypt.txt"));
        write.write(decrypted);
        write.close();

        /*Scanner in = new Scanner(System.in);
        System.out.println("Enter text: ");
        String text = in.nextLine();
        System.out.println("Enter shift: ");
        int shift = in.nextInt();
        String cipher =  encrypt(text, shift);
        System.out.println("Encrypted text: "+ cipher);
        String decryptedPlainText = decrypt(cipher, 26 - shift).toString();
        System.out.println("Decrypted Plain Text: " + decryptedPlainText);*/
    }
}
