import string


def encrypt(abc: str, text: str, key: int) -> str:
    """
    Caesar encryption.

    :param abc: Alphabet of input text.
    :param text: Text for encrypt.
    :param key: Key for Caesar encryption.
    :return: Encryption string.
    """

    words = text.split(' ')

    return ' '.join(map(lambda word: ''.join([abc[(abc.index(letter) + key) % len(abc)] for letter in word.upper()]),
                        words))


def decrypt(abc: str, text: str, key: int) -> str:
    """
    Caesar decryption.

    :param abc: Alphabet of input text.
    :param text: Text for decrypt.
    :param key: Key for Caesar decryption.
    :return: Decryption string.
    """

    words = text.split(' ')

    return ' '.join(map(lambda word: ''.join([abc[(abc.index(letter) - key) % len(abc)] for letter in word.upper()]),
                        words))


ABC = string.ascii_uppercase

input_text = input("Enter your text: ")

try:
    input_key = int(input("Enter you key: "))

    with open('encrypted.txt', 'w+') as f:
        f.write(encrypt(abc=ABC, text=input_text, key=input_key))

    with open('decrypted.txt', 'w+') as f:
        file_str = open('encrypted.txt', 'r').read()
        f.write(decrypt(abc=ABC, text=file_str, key=input_key))

except ValueError:
    print('Key must be an integer.')
