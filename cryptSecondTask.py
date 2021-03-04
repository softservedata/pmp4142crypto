from copy import copy
from math import sqrt
from itertools import count, islice


def gcdExtended(a, b):

    if a == 0 :
        return b, 0, 1

    gcd, x1, y1 = gcdExtended(b%a, a)

    x = y1 - (b//a) * x1
    y = x1

    return gcd, x, y

arr = "abcdefghijklmnopqrstuvwxyz"

a,b = map(int, input("enter key(a b)").split())

if (26%a==0 or a%2==0):
    print(" change a ")
else:
    plain = input("enter text")

    print(plain)


    def encipher(plain, a, b):
        cyper = ""
        for c in plain:
            if c.isalpha():
                cyper += arr[((arr.index(c))*a+b)%26]
            else: cyper += c

        print(cyper)
        return cyper


    cyper = encipher(plain, a,b)

    f = open("cyper.txt", "w")
    f.write(cyper)
    f.close()

print("------------------")

a,b = map(int, input("enter key(a b)").split())

if (26%a==0 or a%2==0):
    print(" change a ")

else:
    cyper = input("enter text")
    print(cyper)
    def decipher(cyper, a,b):
        plain = ""
        a1=gcdExtended(26, a)[2]
        for c in cyper:
            if c.isalpha():
                plain += arr[((arr.index(c)+ 26 - b)*a1) % 26]
            else:
                plain += c

        print(plain)
        return plain


    plain = decipher(cyper, a, b)

