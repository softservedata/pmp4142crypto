text = 'криптосистема'

def encrypt(text, h):
    res = ''
    for i in range(h):
        j = 0
        while i + j < len(text):
            res += text[i + j]
            j += h
    return res

def decrypt(text, h):
    res = list(text)
    k = 0
    for i in range(h):
        j = 0
        while i + j < len(text):
            res[i + j] = text[k]
            k += 1
            j += h
    return ''.join(res)

en = encrypt(text, 3)
print(en)
print(decrypt(en, 3))