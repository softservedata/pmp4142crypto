def load_from_file(filename):
    file = open(filename, "r")
    msg = file.read()
    file.close()
    return msg


arr = "abcdefghijklmnopqrstuvwxyz"

key = input("enter key(string)")
plain = input("enter text")

print(key)
print(plain)

if len(key) < len(plain):
    i = 0
    while len(key) != len(plain):
        key += key[i]
        i += 1
    print(key)


def encipher(plain, key):
    cyper = ""
    for i in range(len(plain)):
        if plain[i].isalpha():
            cyper += arr[(arr.index(plain[i]) + arr.index(key[i])) % len(arr)]
        else:
            cyper += plain[i]

    print(cyper)
    return cyper


cyper = encipher(plain, key)

f = open("cyper.txt", "w")
f.write(cyper)
f.close()

print("------------------")


def decipher(cyper, key):
    plain = ""
    for i in range(len(cyper)):
        if cyper[i].isalpha():
            plain += arr[(arr.index(cyper[i]) + len(arr) - arr.index(key[i])) % len(arr)]
        else:
            plain += cyper[i]

    print(plain)
    return plain


plain = decipher(cyper, key)
