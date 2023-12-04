import os
import re


def main():
    print("Part 1: {}".format(part_one()))
    print("Part 2: {}".format(part_two()))


def part_two():
    res = 0

    path = os.path.abspath(os.path.join(os.path.dirname(__file__), '..', 'inputs/day2.txt'))
    with open(path) as f:
        for line in f.readlines():
            line_split = line.split(':')

            # calculate the power of the minimum number of cubes needed
            res += parse_game2(line_split[1])

    return res


# Return the power of the minimum number of cubes needed for each color
def parse_game2(s):
    revelations = re.split('[,;]', s)

    maxima = {'red': 0, 'blue': 0, 'green': 0}

    for revelation in revelations:
        number = int(revelation.split()[0])
        color = revelation.split()[1]

        if number > maxima[color]:
            maxima[color] = number

    return maxima['red'] * maxima['blue'] * maxima['green']


def part_one():
    res = 0

    path = os.path.abspath(os.path.join(os.path.dirname(__file__), '..', 'inputs/day2.txt'))
    with open(path) as f:
        for line in f.readlines():
            # get the game number from the string
            line_split = line.split(':')
            game_nr = int(line_split[0].split()[1])

            # if the game is possible, at its id to the result
            if parse_game1(line_split[1]):
                res += game_nr

    return res


# Return True if the given game is possible with 12 red cubes, 13 green cubes, and 14 blue cubes
def parse_game1(s):
    allowed = {'red': 12, 'green': 13, 'blue': 14}

    revelations = re.split('[,;]', s)

    for revelation in revelations:
        number = int(revelation.split()[0])
        color = revelation.split()[1]
        if number > allowed[color]:
            return False

    return True


if __name__ == "__main__":
    main()