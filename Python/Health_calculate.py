# -------------------------------------------------------
# 🧮 Health Calculator: BMI, BMR, Calorie Target & Water Intake
# -------------------------------------------------------

def calculate_bmi(weight, height_m):
    """Calculate Body Mass Index (BMI)"""
    return weight / (height_m ** 2)


def calculate_bmr(gender, weight, height_cm, age):
    """Calculate Basal Metabolic Rate (BMR)"""
    if gender.lower() == 'male':
        bmr = (10 * weight) + (6.25 * height_cm) - (5 * age) + 5
    elif gender.lower() == 'female':
        bmr = (10 * weight) + (6.25 * height_cm) - (5 * age) - 161
    else:
        raise ValueError("Gender must be 'male' or 'female'")
    return bmr


def calculate_calorie_target(bmr, activity_level):
    """Calculate daily calorie requirement based on activity"""
    activity_factors = {
        1: 1.2,    # Sedentary
        2: 1.375,  # Lightly active
        3: 1.55,   # Moderately active
        4: 1.725,  # Very active
        5: 1.9     # Extra active
    }
    factor = activity_factors.get(activity_level, 1.2)
    return bmr * factor


def calculate_water_intake(weight):
    """Calculate daily water intake (liters/day)"""
    return weight * 0.033


def main():
    print("🌿 Welcome to the Health Calculator 🌿")
    print("--------------------------------------")

    while True:
        print("\nChoose an option:")
        print(" 1. Calculate BMI (Body Mass Index)")
        print(" 2. Calculate Calorie Target (BMR + Activity)")
        print(" 3. Calculate Daily Water Intake")
        print(" 4. Exit")

        choice = input("Enter your choice (1-4): ").strip()

        if choice == "1":
            print("\n--- BMI Calculation ---")
            weight = float(input("Enter your weight (kg): "))
            height_cm = float(input("Enter your height (cm): "))
            height_m = height_cm / 100
            bmi = calculate_bmi(weight, height_m)
            print(f"\nYour BMI is: {bmi:.2f}")

            # Category
            if bmi < 18.5:
                print("Category: Underweight")
            elif 18.5 <= bmi < 24.9:
                print("Category: Normal weight")
            elif 25 <= bmi < 29.9:
                print("Category: Overweight")
            else:
                print("Category: Obese")

        elif choice == "2":
            print("\n--- Calorie Target Calculation ---")
            gender = input("Enter your gender (male/female): ").strip()
            age = int(input("Enter your age (years): "))
            height_cm = float(input("Enter your height (cm): "))
            weight = float(input("Enter your weight (kg): "))

            print("\nSelect your activity level:")
            print(" 1. Sedentary (little or no exercise)")
            print(" 2. Lightly active (exercise 1–3 days/week)")
            print(" 3. Moderately active (exercise 3–5 days/week)")
            print(" 4. Very active (exercise 6–7 days/week)")
            print(" 5. Extra active (hard physical job or intense exercise)")
            activity_level = int(input("Enter choice (1–5): "))

            bmr = calculate_bmr(gender, weight, height_cm, age)
            calorie_target = calculate_calorie_target(bmr, activity_level)

            print(f"\nYour BMR: {bmr:.2f} kcal/day")
            print(f"Your Daily Calorie Target: {calorie_target:.2f} kcal/day")

        elif choice == "3":
            print("\n--- Water Intake Calculation ---")
            weight = float(input("Enter your weight (kg): "))
            water = calculate_water_intake(weight)
            print(f"\nRecommended Water Intake: {water:.2f} liters/day")

        elif choice == "4":
            print("\n👋 Thank you for using the Health Calculator. Stay healthy!")
            break

        else:
            print("❌ Invalid choice! Please enter a number between 1 and 4.")


if __name__ == "__main__":
    main()
