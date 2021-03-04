a = 'abcdefghijklmnopqrstuvwxyz'
text = 'some text'
k=6

encrypt = lambda x, k: ''.join(map(lambda t: (a[k:] + a[:k])[a.index(t)] if t in a else t, x))
decrypt = lambda x, k: ''.join(map(lambda t: a[a.index(t) - k] if t in a else t, x))

print(encrypted := encrypt(text, k))
print(decrypt(encrypted, k))
