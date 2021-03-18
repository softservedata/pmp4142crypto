public class Main {
    public static void main (String args[]){
        FenceCipher cipher = new FenceCipher();
        String message = "lviv university";
        String encrypted = cipher.encrypt(message, 3);
        System.out.println("Message: " + message);

        System.out.println("Encrypted message: "+ encrypted);
        System.out.println("Decrypted message: "+ cipher.decrypt(encrypted,3));

    }
}
