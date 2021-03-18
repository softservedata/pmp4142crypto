public class FenceCipher {

    public String encrypt(String text, int key){
        String res = "";
        char[][] matrix = new char[key][text.length()];
        int j = 0;
        int i = 0;
        boolean moveDown = true;
        while (j<text.length()){
            if(moveDown){
                matrix[i][j] = text.charAt(j);
                i++; j++;
                if (i == key-1){
                    moveDown=false;
                }
            }
            else{
                matrix[i][j]=text.charAt(j);
                i--; j++;
                if (i==0){
                    moveDown=true;
                }
            }
        }

        for(int k = key-1; k>=0;k--){
            for(int m =0; m<text.length(); m++){

                if(matrix[k][m] !='\0'){
                    res+=matrix[k][m];
                }
            }
        }
        return res;
    }

    public String decrypt(String text, int key){
        String res = "";
        char[][]matrix = new char[key][text.length()];
        int i = 0;
        int j = 0;
        boolean moveDown = true;

        while(j<text.length()){

            if(moveDown){
                matrix[i][j] = '1';
                i++; j++;

                if(i == key-1){
                    moveDown = false;
                }
            }
            else{
                matrix[i][j]= '1';
                i--; j++;
                if (i == 0) {
                    moveDown = true;
                }
            }
        }

        int temp = 0;

        for(int k = key-1; k>=0; k--){
            for(int m =0; m<text.length();m++){

                if(matrix[k][m] == '1'){
                    matrix[k][m]=text.charAt(temp);
                    temp++;
                }
            }
        }
        i = 0;
        j = 0;
        moveDown = true;

        while(j<text.length()){

            if(moveDown){
                res += matrix[i][j];
                i++; j++;
                if (i == key-1){
                    moveDown=false;
                }
            }

            else{
                res += matrix[i][j];
                i--; j++;
                if(i == 0){
                    moveDown =true;
                }
            }
        }

        return res;
    }
}
