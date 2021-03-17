a = 'abcdefghijklmnopqrstuvwxyz'

def gcd(a,b):
    if a < b:
        a, b = b, a
    if b == 0:
        return a
    
    x1, x2 = 0, 1
    y1, y2 = 1, 0

    while b > 0:
        q = a // b
        r = a - q * b
        x = x2 - q * x1
        y = y2 - q * y1
        print((a, b, q, r, x, y))
        a, b = b, r
        x1, x2 = x, x1
        y1, y2 = y, y1
    return (a, x2, y2)


ll = len(a)


def encrypt(text, key):
    res = ''
    for s in text:
        if s.lower() not in a:
            res += s
        else:
            res += a[(key[0] * a.index(s) + key[1]) % ll] if s.islower() else a[(key[0] * a.index(s.lower()) + key[1]) % ll].upper()
    return res


def decrypt(text, key):
    res = ''
    key[0] = gcd(26, key[0])[2]
    for s in text:
        if s.lower() not in a:
            res += s
        else:
            res += a[((a.index(s) + ll - key[1]) * key[0]) % ll] if s.islower() else \
                   a[((a.index(s.lower()) + ll - key[1]) * key[0]) % ll].upper()
    return res


key = [3, 5]
text = 'Chel, ARE you here?'

print(short_text := encrypt(text, key))
print(decrypt(short_text, key))