package cryptography

import java.util.stream.IntStream

def encryptMessage(alpha, beta, char[] msg) {
    msg.collect { c ->
        int offset = c.isUpperCase() ? 'A' : 'a';
        c.isLetter() ? ((((alpha * ((c as int) - offset)) + beta) % 26) + offset) as char : c
    }.join()
}

def decryptCipher(alpha, beta, cipher) {
    // alpha mod 26
    int alphaModM = IntStream.range(0, 26)
            .filter(number -> (alpha * number) % 26 == 1)
            .findFirst().orElseThrow()

    cipher.chars.collect { c ->
        int offset = c.isUpperCase() ? 'A' : 'a';
        c.isLetter() ? (((alphaModM * (((c as int) - offset + 26 - beta)) % 26)) + offset) as char : c
    }.join()
}

def text = System.in.text
def action = args.length > 0 ? args[0] : '-e';
def alpha = 3;
def beta = 6;
def alphaModM = 23;

if (['-d', '--decode', 'decode'].contains(action)) {
    println decryptCipher(alpha, beta, text)
} else {
    println encryptMessage(alpha, beta, text.chars)
}
