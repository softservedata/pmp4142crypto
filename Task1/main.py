def encrypt(file, key):
    result = ""

    with open(file, "r") as f:
        text = f.read()
    for i in range(len(text)):
        char = text[i]
        result += chr(ord(char) + key)


    with open("cipher.le", "w") as f:
        f.write(result)
    return "Done"

def decipher(file,key):
    result = ""
    with open(file, "r") as f:
        text = f.read()
    for i in range(len(text)):
        char = text[i]
        result += chr(ord(char) - key)
    with open("decipher.le", "w") as f:
        f.write(result)
    return "Done"
while True:
    print("What do you want to do? e/d: ")
    res=str(input('>>> ')).lower()
    if res=="e":
        file=str(input("input file name: "))
        key=int(input("input key: "))
        encrypt(file,key)
    if res=="d":
        file = str(input("input file name: "))
        key = int(input("input key: "))
        decipher(file,key)
    if res=="n":
        break





