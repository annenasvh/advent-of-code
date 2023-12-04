import os
import re


def main():
    # print("Part 1: {}".format(part_one()))
    print("Part 2: {}".format(part_two()))


def part_two():
    path = os.path.abspath(os.path.join(os.path.dirname(__file__), '..', 'inputs/day1.txt'))
    with open(path) as f:
        return sum([get_value2(line) for line in f.readlines()])


def part_one():
    path = os.path.abspath(os.path.join(os.path.dirname(__file__), '..', 'inputs/day1.txt'))
    with open(path) as f:
        return sum([get_value(line) for line in f.readlines()])


def get_value2(s):
    values = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]
    values_to_int = dict(zip(values, range(10)))

    res_left = dict.fromkeys(values)
    res_right = dict.fromkeys(values)

    # find first and last occurence of typed out integers
    for val in values:
        res_left[val] = s.find(val)
        res_right[val] = s[::-1].find(val[::-1])

    # find first typed out integer
    first = None
    first_index = None
    for k, v in res_left.items():
        if (first_index is None or v < first_index) and v != -1:
            first = k
            first_index = v

    # find last typed out integer
    last = None
    last_index = None
    for k, v in res_right.items():
        if (last_index is None or v < last_index) and v != -1:
            last = k
            last_index = v

    # find first digit
    for (i, char) in enumerate(s):
        # the first spelled out digit comes before any int is found
        if first_index is not None and i > first_index:
            digit1 = values_to_int[first]
            break

        if char.isdigit():
            digit1 = int(char)
            break

    # find second digit
    for (i, char) in enumerate(reversed(s)):
        # the first spelled out digit comes before any int is found
        if last_index is not None and i > last_index:
            digit2 = values_to_int[last]
            break

        if char.isdigit():
            digit2 = int(char)
            break

    return 10 * digit1 + digit2


def get_value(s):
    for char in s:
        if char.isdigit():
            digit1 = int(char)
            break

    for char in reversed(s):
        if char.isdigit():
            digit2 = int(char)
            break

    return 10 * digit1 + digit2


if __name__ == "__main__":
    main()
