package edu.lnu.crypto;

public class PalisadeCipher {
    private enum Direction {
        UP, DOWN
    }

    public String encrypt(String text, int height) {
        var matrix = new char[height][text.length()];
        int currChar = 0;
        int currHeight = 0;
        var direction = Direction.DOWN;

        while (currChar < text.length()) {
            matrix[currHeight][currChar] = text.charAt(currChar);
            currChar++;
            if (direction == Direction.DOWN) {
                currHeight++;
                if (currHeight == height - 1) {
                    direction = Direction.UP;
                }
            } else {
                currHeight--;
                if (currHeight == 0) {
                    direction = Direction.DOWN;
                }
            }
        }

        var result = new StringBuilder();
        for (int i = height - 1; i >= 0; i--) {
            for (int j = 0; j < text.length(); j++) {
                if (matrix[i][j] != '\0') {
                    result.append(matrix[i][j]);
                }
            }
        }
        return result.toString();
    }

    public String decrypt(String text, int key) {
        var result = new StringBuilder();
        var matrix = new char[key][text.length()];
        int currHeight = 0;
        int currChar = 0;
        var direction = Direction.DOWN;

        while (currChar < text.length()) {
            matrix[currHeight][currChar] = '1';
            currChar++;
            if (direction == Direction.DOWN) {
                currHeight++;
                if (currHeight == key - 1) {
                    direction = Direction.UP;
                }
            } else {
                currHeight--;
                if (currHeight == 0) {
                    direction = Direction.DOWN;
                }
            }
        }

        int temp = 0;

        for (int k = key - 1; k >= 0; k--) {
            for (int m = 0; m < text.length(); m++) {

                if (matrix[k][m] == '1') {
                    matrix[k][m] = text.charAt(temp);
                    temp++;
                }
            }
        }
        currHeight = 0;
        currChar = 0;
        direction = Direction.DOWN;

        while (currChar < text.length()) {
            result.append(matrix[currHeight][currChar]);
            if (direction == Direction.DOWN) {
                currHeight++;
                currChar++;
                if (currHeight == key - 1) {
                    direction = Direction.UP;
                }
            } else {
                currHeight--;
                currChar++;
                if (currHeight == 0) {
                    direction = Direction.DOWN;
                }
            }
        }

        return result.toString();
    }
}