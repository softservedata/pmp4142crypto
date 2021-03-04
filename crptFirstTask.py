
arr = "abcdefghijklmnopqrstuvwxyz"

key = int(input("enter key(shift)"))
plain = input("enter text")
print(plain)


def encipher(plain, key):
    cyper = ""
    for c in plain:
        if c.isalpha() : cyper += arr[(arr.index(c)+key)%26]
        else: cyper += c

    print(cyper)
    return cyper


cyper = encipher(plain, key)

f = open("cyper.txt", "w")
f.write(cyper)
f.close()

print("------------------")

key = int(input("enter key(shift)"))
cyper = input("enter text")
print(cyper)
def decipher(cyper, key):
    plain = ""
    for c in cyper:
        if c.isalpha():
            plain += arr[(arr.index(c) - key) % 26]
        else:
            plain += c

    print(plain)
    return plain


plain = decipher(cyper, key)
