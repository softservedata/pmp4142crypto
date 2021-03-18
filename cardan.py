def load_from_file(filename):
    file = open(filename, "r")
    size = file.readline()
    holes = file.readline()
    file.close()
    grid = Grid(size, holes)
    return grid


class Grid:

    def __init__(self, size, holes):
        self.size = int(size)
        # Converting string into a sequence of numbers.
        self.holes = str(holes)
        self.holes = self.holes.replace("[", '')
        self.holes = self.holes.replace("]", '')
        self.holes = self.holes.replace("(", '')
        self.holes = self.holes.replace(")", '')
        self.holes = self.holes.replace(",", '')
        self.holes = self.holes.replace(" ", '')
        hollow_matrix = []
        i = 0
        cont = 0
        while i < self.size * self.size / 4:
            t = int(self.holes[cont]), int(self.holes[cont + 1])
            cont = cont + 2
            i = i + 1
            hollow_matrix.append(t)

        self.holes = hollow_matrix

    def encrypt(self, message):
        offset = 0
        encrypt_message = ""

        # An array of nxn cells to store the letters.
        matrix = []
        for i in range(self.size * 2 - 1):
            matrix.append([])
            for j in range(self.size):
                matrix[i].append(None)
        whitespace = self.size * self.size - len(message) % (self.size * self.size)
        if len(message) % (self.size * self.size) != 0:
            for i in range(whitespace):
                message = message + ' '
        while offset < len(message):

            # Adding an order to the coordinates(the first letter in the box at the top left and etc).
            self.holes.sort()

            # Adding letters in the holes.
            the_range = int(self.size * self.size / 4)
            for i in range(the_range):
                xy = self.holes[i]
                x = xy[0]
                y = xy[1]
                matrix[x][y] = message[offset]
                offset = offset + 1

            if (offset % (self.size * self.size)) == 0:
                for i in range(self.size):
                    for j in range(self.size):
                        encrypt_message = encrypt_message + matrix[i][j]

            for i in range(the_range):
                x = (self.size - 1) - self.holes[i][1]
                # The coordinates of the new columns are the old rows'.
                y = self.holes[i][0]
                self.holes[i] = x, y
        print(matrix)
        return encrypt_message

        # Here we go again(just backwards).

    def decode(self, message, size):
        offset = 0
        decoded_message = ""

        # An array of nxn cells to store the letters.
        matrix = []
        for i in range(self.size * 2 - 1):
            matrix.append([])
            for j in range(self.size):
                matrix[i].append(None)

        whitespace = self.size * self.size - len(message) % (self.size * self.size)
        if len(message) % (self.size * self.size) != 0:
            for h in range(whitespace):
                message = message + ' '
        offset_msg = len(message) - 1
        while offset < len(message):
            # Adding the message in the nxn table.
            if (offset % (self.size * self.size)) == 0:
                for i in reversed(range(self.size)):
                    for j in reversed(range(self.size)):
                        matrix[i][j] = message[offset_msg]
                        offset_msg = offset_msg - 1

            # The turn tables.
            the_range = int(self.size * self.size / 4)
            for i in reversed(range(the_range)):
                # The coordinates of the new rows are the old columns'.
                x = self.holes[i][1]
                # The coordinates of the new columns:
                # 0 = rows, 1 = columns
                y = (self.size - 1) - self.holes[i][0]
                self.holes[i] = x, y

            self.holes.sort(reverse=True)
            # The letters from the holes(from the bottom right)
            for i in range(the_range):
                xy = self.holes[i]
                x = xy[0]
                y = xy[1]
                decoded_message = matrix[x][y] + decoded_message
                offset = offset + 1

        return decoded_message

    def save(self, filename):
        file = open(filename, 'w')
        file.write(str(self.size))
        file.write('\n')
        file.write(str(self.holes).replace(" ", ''))
        file.close()


# grid = load_from_file("cardanofile.txt")
# msg = grid.encrypt("Ghost Busters")
# print("ENTIRE encoded message:", msg)
# decoded_msg = grid.decode(msg, 16)
# print("FULL decoded message:", decoded_msg)
# grid.save("cypher.txt")


gaps = [(7, 7), (6, 0), (5, 0), (4, 0), (7, 1), (1, 1), (1, 2), (4, 1 ), (7, 2), (2, 1), (2, 5), (2, 3), (7, 3), (3, 1), (3, 2), (3, 4)]
grid = Grid(8, gaps)
text = "I don't really like rats, there are not cool man, gross, but mice on the other side are cuties"
msg_len = len(text)
msg = grid.encrypt(text)
print(text)
print(msg)
print(grid.decode(msg, msg_len))
