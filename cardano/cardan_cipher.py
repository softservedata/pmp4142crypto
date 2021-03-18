import numpy as np

class Grille:
    def __init__(self):
        self.grille = self.read_grille()

    @staticmethod
    def rotate(m, kk=0):
        m = np.rot90(m, k=3-kk)
        return m

    def read_grille(self):
        m = []
        with open('cardan_grille.txt', 'r') as f:
            self.m = int(f.readline())
            print(type(self.m))
            for i in range(self.m):
                m.append(list(map(int, f.readline().split())))
        return np.array(m)

    def get_blocks(self, text):
        blocks = []
        while True:
            if len(text) >= self.m ** 2:
                blocks.append(text[:self.m ** 2])
                text = text[self.m ** 2:]
            else:
                blocks.append(text.ljust(self.m ** 2))
                break
        return list(filter(lambda x: x.strip(), blocks))

    def encrypt(self, text):
        msg = ''
        blocks = self.get_blocks(text)
        for block in blocks:
            res = [0 for _ in range(self.m ** 2)]
            ords = list(map(ord, block))
            for rot in range(0, -4, -1):
                part, ords = ords[:self.m], ords[self.m:]
                gr = np.rot90(self.grille, k=rot).flatten()
                ones = [i for i, x in enumerate(gr) if x]
                for i, l in zip(ones, part):
                    res[i] = l
            msg += ''.join(map(chr, res))
        return msg


    def decrypt(self, text):
        msg = ''
        blocks = self.get_blocks(text)
        for block in blocks:
            res = []
            ords = list(map(ord, block))
            for rot in range(0, -4, -1):
                gr = np.rot90(self.grille, k=rot).flatten()
                ones = [i for i, x in enumerate(gr) if x]         
                [res.append(ords[i]) for i in ones]

            msg += ''.join(map(chr, res))
        return msg


g = Grille()

print(g.grille)

en = g.encrypt('abcdefghijklmnopqrstuvwxyz')
print(en)
print(g.decrypt(en))
