import numpy as np
a = 'abcdefghijklmnopqrstuvwxyz'


def encrypt(text, key):
    gamma = len(key)
    ords = np.array(list(map(ord, text)))
    keys = []

    k = 0
    for _ in range(len(text)):
        keys.append(key[k])
        k = (k + 1) % gamma
    res = list(map(chr, ords + keys))

    return ''.join(res)


def decrypt(text, key):
    gamma = len(key)
    ords = np.array(list(map(ord, text)))
    keys = []

    k = 0
    for _ in range(len(text)):
        keys.append(key[k])
        k = (k + 1) % gamma
    res = list(map(chr, ords - keys))

    return ''.join(res)


key = 'bddc'
key = list(map(lambda x: a.index(x), key))

en = encrypt('привіт', key)
print(en)
print(decrypt(en, key))