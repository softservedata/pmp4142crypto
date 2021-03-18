import random
from collections import namedtuple


class PublicKey(namedtuple('PublicKey', 'n e')):
    __slots__ = ()

    def encrypt(self, x):
        return pow(x, self.e, self.n)


class PrivateKey(namedtuple('PrivateKey', 'n d')):
    __slots__ = ()

    def decrypt(self, x):
        return pow(x, self.d, self.n)


def get_d(e, phi):
    d_old = 0
    r_old = phi
    d_new = 1
    r_new = e
    while r_new > 0:
        a = r_old // r_new
        (d_old, d_new) = (d_new, d_old - a * d_new)
        (r_old, r_new) = (r_new, r_old - a * r_new)
    return d_old % phi if r_old == 1 else None


def get_primes(start, stop):
    if start >= stop:
        return []

    primes = [2]

    for n in range(3, stop + 1, 2):
        for p in primes:
            if n % p == 0:
                break
        else:
            primes.append(n)

    while primes and (primes[0] < start or primes[0] > stop):
        del primes[0]

    return primes


def are_relatively_prime(a, b):
    for n in range(2, min(a, b) + 1):
        if a % n == b % n == 0:
            return False
    return True

def split_to_fit_n(bin_plain, n):
    i = 1
    bin_plain_arr = [bin_plain]
    while True:
        if_fits = []
        for b in bin_plain_arr:
            if int(b, 2) < n-1:
                if_fits.append(1)
            else:
                if_fits.append(0)
        if if_fits.__contains__(0):
            i += 1
            bin_plain_arr = []
            for j in range(i):
                bin_plain_arr.append(bin_plain[j*len(bin_plain)//i :(j+1)*len(bin_plain) // i])
        else:
            break
    return bin_plain_arr



def get_key_pair(n, e):

    primes = get_primes(0, n)
    p = 1
    q = 1
    while primes:
        p = random.choice(primes)
        primes.remove(p)
        q_candidates = [q for q in primes
                        if p * q == n]
        if q_candidates:
            q = random.choice(q_candidates)
            break

    phi = (p - 1) * (q - 1)
    print(p, q)
    d = get_d(e, phi)

    return PublicKey(p * q, e), PrivateKey(p * q, d)


arr = "abcdefghijklmnopqrstuvwxyz"
plain = 'if I tell you a secret, will you keep it?'
binary_plain=''


n = 537
e = 7

solution = get_key_pair(n, e)


binary_plain = ''.join(format(ord(i), '08b') for i in plain)

if int(binary_plain, 2) < n-1:
    # print(int(binary_plain, 2))
    encrypted_msg = solution[0].encrypt(int(binary_plain, 2))
    decrypted_msg = solution[1].decrypt(encrypted_msg)

else:
    print(binary_plain)
    # binary_plain_arr = split_to_fit_n(binary_plain, n)
    binary_plain_arr = [format(ord(i), '08b') for i in plain]

    encrypted_arr = []
    binary__arr = []
    for b in binary_plain_arr:
        binary__arr.append(int(b, 2))
        encrypted_arr.append(solution[0].encrypt(int(b, 2)))

    print(encrypted_arr)

    binary_ecrypted_msg =[]
    ecrypted_msg = ''
    for i in encrypted_arr:
        binary_ecrypted_msg.append(format(i, '08b'))
    for b in binary_ecrypted_msg:
        ecrypted_msg += chr(int(b, 2))
    print(ecrypted_msg)

    decrypted_arr = []
    for e in encrypted_arr:
        decrypted_arr.append(solution[1].decrypt(e))
    print(decrypted_arr)

    binary_decrypted_msg =[]
    decrypted_msg = ''
    for i in decrypted_arr:
        binary_decrypted_msg.append(format(i, '08b'))
    for b in binary_decrypted_msg:
        decrypted_msg += chr(int(b, 2))
    print(decrypted_msg)
#



# solution = get_key_pair(527, 7)
# decrypted_msg = "ŎġĘ,Ę[!ttĘơāĘmĘ!ä![ĘwŎttĘơāĘp!!ŻĘŎ[ǒ"
# binary_decrypted_arr = [format(ord(i), '08b') for i in decrypted_msg]
# decrypted_arr=[]
# for i in binary_decrypted_arr:
#     decrypted_arr.append(int(i, 2))
#
# decrypted_arr_sec = []
#
# for i in decrypted_arr:
#     decrypted_arr_sec.append(solution[1].decrypt(i))
#
# binary_decrypted_msg =[]
# decrypted_msg = ''
# for i in decrypted_arr_sec:
#     binary_decrypted_msg.append(format(i, '08b'))
# for b in binary_decrypted_msg:
#     decrypted_msg += chr(int(b, 2))
# print(decrypted_msg)





