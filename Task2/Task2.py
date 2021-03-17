import string

A = 3
B = 4


def encryption(abc: str, text: str, key_a: int, key_b: int) -> str:
    return ''.join(list(map(lambda x: abc[(key_a * abc.find(x) + key_b) % len(abc)], text.upper())))


def gcd_extended(a, b):
    if a == 0:
        return b, 0, 1
    gcd, x1, y1 = gcd_extended(b % a, a)
    x = y1 - (b//a) * x1
    y = x1
    return gcd, x, y


def description(abc: str, text: str, key_a: int, key_b: int) -> str:
    gcd, t, y = gcd_extended(key_a, len(abc))
    if gcd == 1:
        t = (t % len(abc) + len(abc)) % len(abc)
    return ''.join(list(map(lambda x: abc[t * (abc.find(x) + len(abc) - key_b) % len(abc)], text)))


text = 'ATTACKATDAWN'
encr_text = encryption(abc=string.ascii_uppercase, text=text, key_a=A, key_b=B)
print(encr_text)
decr_text = description(abc=string.ascii_uppercase, text=encr_text, key_a=A, key_b=B)
print(decr_text)