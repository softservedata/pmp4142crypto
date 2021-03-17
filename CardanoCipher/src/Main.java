public class Main {

    public static void main(String args[]){

        CardanoCipher cardano = new CardanoCipher();
        String message = "lviv university";
        System.out.println("Message: " + message);
        String encryptedMessage = cardano.encrypt(message, new int[]{2,5,0,8});
        System.out.println("Encrypted message: " + encryptedMessage);
        String decryptedMessage = cardano.decrypt(encryptedMessage, new int[]{2,5,0,8});
        System.out.println("Decrypted message: " + decryptedMessage);
    }
}
