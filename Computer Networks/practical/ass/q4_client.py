# # Develop a client-server application using TCP where the client will send two operands and 
# # an operator to the server in operand1 operator operand2 format and the server will calculate 
# # the result and display it. Allowed operators are +, -, *, /, %. 


import socket

def client_program():
    host = socket.gethostname()
    port = 5000

    print("Client is starting on host:", host)

    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client_socket.connect((host, port))

    while True:
        a = input("Enter the number1: ")
        if a.lower().strip() == "exit":
            # Inform server also before shutting down
            client_socket.send("exit".encode())
            print("Client exiting...")
            break

        b = input("Enter the operator: ")
        c = input("Enter the number2: ")

        # Combine into one string
        message = f"{a},{b},{c}"
        client_socket.send(message.encode())

        # Receive result from server
        data = client_socket.recv(1024).decode()
        print("Result show from the client side: " + data)
        print("\n")
    client_socket.close()

if __name__ == '__main__':
    client_program()


# PS E:\repositary\3rd_Year_5th_Semester\Computer Networks\practical\ass> python .\q4_client.py
# Client is starting on host: SUKDEB
# Enter the number1: 26
# Enter the operator: +
# Enter the number2: 67
# Result show from the client side: 93


# Enter the number1: 65
# Enter the operator: -
# Enter the number2: 34
# Result show from the client side: 31


# Enter the number1: 56
# Enter the operator: *
# Enter the number2: 21
# Result show from the client side: 1176


# Enter the number1: 56
# Enter the operator: /
# Enter the number2: 2
# Result show from the client side: 28.0


# Enter the number1: 45
# Enter the operator: /
# Enter the number2: 0
# Result show from the client side: Error beacuase Division by zero


# Enter the number1: 26
# Enter the operator: %
# Enter the number2: 0
# Result show from the client side: Error beacuase Modulo by zero


# Enter the number1: 34
# Enter the operator: 
# Enter the number2: 7
# Result show from the client side: Invalid operator


# Enter the number1: 78
# Enter the operator: &
# Enter the number2: 5
# Result show from the client side: Invalid operator


# Enter the number1: exit
# Client exiting...