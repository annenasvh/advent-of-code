import os
import numpy as np


def main():
    strategies = read_input()
    scores = [calc_score(opponent, player) for (opponent, player) in strategies]
    scores2 = [calc_score2(opponent, player) for (opponent, player) in strategies]

    print("The strategy would give you: " + str(sum(scores)) + " points")
    print("The actual strategy would give you: " + str(sum(scores2)) + " points")

def calc_score(opponent, player):
    win = 6
    tie = 3
    loose = 0
    x = 1
    y = 2
    z = 3

    if opponent == 'A' and player == 'X':
        return tie + x
    elif opponent == 'A' and player == 'Y':
        return win + y
    elif opponent == 'A' and player == 'Z':
        return loose + z
    elif opponent == 'B' and player == 'X':
        return loose + x
    elif opponent == 'B' and player == 'Y':
        return tie + y
    elif opponent == 'B' and player == 'Z':
        return win + z
    elif opponent == 'C' and player == 'X':
        return win + x
    elif opponent == 'C' and player == 'Y':
        return loose + y
    elif opponent == 'C' and player == 'Z':
        return tie + z
    else:
        raise Exception("Invalid strategy")


def calc_score2(opponent, result):
    win = 6
    tie = 3
    loose = 0
    rock = 1
    paper = 2
    scissors = 3

    if opponent == 'A' and result == 'X':
        return scissors + loose
    elif opponent == 'A' and result == 'Y':
        return rock + tie
    elif opponent == 'A' and result == 'Z':
        return paper + win
    elif opponent == 'B' and result == 'X':
        return rock + loose
    elif opponent == 'B' and result == 'Y':
        return paper + tie
    elif opponent == 'B' and result == 'Z':
        return scissors + win
    elif opponent == 'C' and result == 'X':
        return paper + loose
    elif opponent == 'C' and result == 'Y':
        return scissors + tie
    elif opponent == 'C' and result == 'Z':
        return rock + win
    else:
        raise Exception("Invalid strategy")

def read_input():
    """
    Reads the input and parses it into a 2d numpy array
    :return: 2d numpy  array, where the first column is the opponents move, and the second the player's
    """
    path = os.path.abspath(os.path.join(os.path.dirname(__file__), '..', 'inputs/day2.txt'))

    rows = []
    with open(path) as file:
        for line in file.readlines():
            # rows.append([line[0], line[2]])
            rows.append((line[0], line[2]))
    return rows
    # return np.array(rows)


if __name__ == "__main__":
    main()
