from collections import defaultdict

a = 'abcdefghijklmnopqrstuvwxyz'
ll = len(a)


def encrypt(text, key):
    res = ''
    for s in text:
        if s.lower() not in a:
            res += s
        else:
            res += a[(a.index(s) + key) % ll] if s.islower() else a[(a.index(s.lower()) + key) % ll].upper()
    return res


def decrypt(text, key):
    res = ''
    for s in text:
        if s.lower() not in a:
            res += s
        else:
            res += a[(a.index(s) + ll - key) % ll] if s.islower() else \
                   a[(a.index(s.lower()) + ll - key) % ll].upper()
    return res


def get_frequency(text):
    text = text.lower()
    number = {s: text.count(s) for s in a}
    symb_sum = sum(number.values())
    frequency = {k: v/symb_sum for k, v in number.items()}
    return frequency


def guess_key(main_freq, text_freq):
    main_most = max(main_freq, key=main_freq.get)
    text_most = max(text_freq, key=text_freq.get)
    key = (ll - a.index(main_most) + a.index(text_most)) % ll
    print("""
        Main text most frequent letter: {},
        encrypted text most frequent letter: {}; 
        guessed key = {}""".format(main_most, text_most, key))
    return key

with open('alice_in_wonderland.txt') as f:
    text = f.read()
frequency = get_frequency(text)

long_text = """
  Either the well was very deep, or she fell very slowly, for she
had plenty of time as she went down to look about her and to
wonder what was going to happen next.  First, she tried to look
down and make out what she was coming to, but it was too dark to
see anything; then she looked at the sides of the well, and
noticed that they were filled with cupboards and book-shelves; 
here and there she saw maps and pictures hung upon pegs.  She
took down a jar from one of the shelves as she passed; it was
labelled `ORANGE MARMALADE', but to her great disappointment it
was empty:  she did not like to drop the jar for fear of killing
somebody, so managed to put it into one of the cupboards as she
fell past it.
"""

# decrypt with known key
key = 3
print(short_text := encrypt('abc   dsf DEf', key))
print(decrypt(short_text, key))


encrypted_long = encrypt(long_text, 28)

freq = get_frequency(encrypted_long)

guessed_key = guess_key(frequency, freq)

print(decrypt(encrypted_long, guessed_key))