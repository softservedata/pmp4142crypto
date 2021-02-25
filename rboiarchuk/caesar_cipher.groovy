package cryptography


def caesarEncode(key, text) {
    text.chars.collect { c ->
        int offset = c.isUpperCase() ? 'A' : 'a'
        c.isLetter() ? (((c as int) - offset + key) % 26 + offset) as char : c
    }.join()
}

def caesarDecode(cipherKey, text) {
    caesarEncode(26 - cipherKey, text)
}

def text = System.in.text.trim()
def key = args[0] as int
def action = args.length > 1 ? args[1] : '-e';

if (['-d', '--decode', 'decode'].contains(action)) {
    println caesarDecode(key, text)
} else {
    println caesarEncode(key, text)
}
