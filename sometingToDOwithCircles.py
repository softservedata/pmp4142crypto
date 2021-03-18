def encrypt(msg, key):
    result = ""
    for i in range(key):
        j = 0
        while i + j < len(msg):
            result += msg[i + j]
            j += key

    return result


def decrypt(msg, key):
    result = list(msg)
    k = 0
    for i in range(key):
        j = 0
        while i + j < len(msg):
            result[i + j] = msg[k]
            k += 1
            j += key

    res = ""
    return res.join(result)


def load_from_file(filename):
    file = open(filename, "r")
    msg = file.read()
    file.close()
    return msg

message = "If I tell you a secret, will you keep it?"
encrypted = encrypt(message, 3)

decrypted = decrypt(encrypted, 3)

print(message)
print(encrypted)
f = open("cyper.txt", "w")
f.write(encrypted)
f.close()

print(decrypted)
