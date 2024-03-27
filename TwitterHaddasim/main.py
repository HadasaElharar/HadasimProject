import math

def trianglePerimeter(height,base):
    side_length = (height ** 2 + (base / 2) ** 2) ** 0.5

    print("The Triangle Perimeter : ", (side_length*2)+base)
def triangleArea(height,base):
    # countReduce = (base-1)/2-1
    # countRound = int((height-2)/countReduce)
    # countTop = int((height-2)%countReduce)
    # print("*"*int(base))
    # base = base - 2
    # space = + 1
    # while base > countTop:
    #     for i in range(int(countRound)):
    #         print(" "*int(space) + "*"*int(base))
    #     space = space+1
    #     base = base-2
    # for i in range(int(countTop)):
    #     print(" " * int(space-1) + "*" * int(3))
    # print(" "*int(space)+"*")
    top = base/2
    countRound = int((height - 2) / ((base - 1) / 2 - 1)) #מספר הקומות שכל מספר אי זוגי יופיע
    countTop = int((height - 2) % ((base - 1) / 2 - 1)) #השארית עבור הקומות העליונות
    print(" "*int(top)+"*")
    top = top-1
    num = 3
    for i in range(int(countTop)):
        print(" " * int(top) + "*" * int(num))
    while top > 1:
        for i in range(int(countRound)):
            print(" " * int(top) + "*" * int(num))
        num = num + 2
        top = top - 1
    print("*" * int(base))

def rectangle():
    height = 0
    while height < 2:
        height = float(input("Enter the height of the rectangle (must be greater than 2): "))
    width = float(input("Enter the width of the rectangle: "))
    area = height * width
    if abs(height - width) > 5:
        print("The area  is:", area)
    else:
        print("The perimeter  is:", 2 * (height + width))

def triangle():
    height = 0
    while height < 2:
        height = float(input("Enter the height of the triangle (must be greater than 2): "))
    base = float(input("Enter the base of the triangle: "))
    print("1. TrianglePerimeter")
    print("2. TriangleArea")
    choice = input("Enter your choice: ")
    if choice == "1":
        trianglePerimeter(height,base)
    else:
        if base % 2 == 0 or base > height * 2 or (base == 3 and height == 3):
            print("Cannot print the triangle.")
        else:
            triangleArea(height,base)

def main():
    choice = ""
    while choice != "3":
        print("\nMenu:")
        print("1. Rectangle")
        print("2. Triangle")
        print("3. Exit")
        choice = input("Enter your choice: ")

        if choice == "1":
            rectangle()
        elif choice == "2":
            triangle()
        elif choice != "3":
            print("Invalid choice. Please try again.")

    print("Exiting the program.")

if __name__ == "__main__":
    main()
