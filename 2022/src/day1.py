import os


def main():
    calories = read_input()
    calories_sum = [sum(elf) for elf in calories]
    calories_sum_sorted = sorted(calories_sum, reverse=True)

    print("The most calories an elf carries: " + str(max(calories_sum)))
    print("The top three elves are together carrying: " + str(sum(calories_sum_sorted[:3])))


def read_input():
    path = os.path.abspath(os.path.join(os.path.dirname(__file__), '..', 'inputs/day1.txt'))
    with open(path) as file:
        calories = []
        current_elf = []

        for line in file.readlines():
            # if the line is empty
            if not line.strip():        # alternative: if line.isspace():
                calories.append(current_elf)
                current_elf = []
            else:
                current_elf.append(int(line))
    return calories


if __name__ == '__main__':
    main()
