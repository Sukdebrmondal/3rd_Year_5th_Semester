# # Develop a client-server application using TCP where the client will send two operands and 
# # an operator to the server in operand1 operator operand2 format and the server will calculate 
# # the result and display it. Allowed operators are +, -, *, /, %. 





import socket  

def server_program():
    # Get the hostname of the machine 
    host = socket.gethostname()
    port = 5000   # Port number for the server

    print("Server is starting on host:", host)

    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

    # Bind socket with host and port
    server_socket.bind((host, port))

    # Server can listen for incoming client requests
    server_socket.listen(1)   

    # Accept client connection 
    connection, address = server_socket.accept()
    print("Connected to client:", str(address))

    while True:
        # Receive data from client
        data = connection.recv(1024).decode()
        if not data:
            break
        if data.lower().strip() == "exit":
            print("Exit command received. Server shutting down.")
            break

        # Split the received message
        a, b, c = map(str, data.split(","))
        a = int(a)   
        c = int(c)   

        try:
            if b == "+":
                res = a + c
            elif b == "-":
                res = a - c
            elif b == "*":
                res = a * c
            elif b == "/":
                if c == 0:
                    res = "Error beacuase Division by zero"
                else:
                    res = a / c
            elif b == "%":
                if c == 0:
                    res = "Error beacuase Modulo by zero"
                else:
                    res = a % c

            else:
                res = "Invalid operator"
        except Exception as e:
            print(e)

        # Convert result into string 
        message = str(res)

        # Show result
        print("Result calculated on server:", message)
        print("\n")

        # Send result back to client
        connection.send(message.encode())


    # Close the server socket
    server_socket.close()

if __name__ == '__main__':
    server_program()


# Server is starting on host: SUKDEB
# Connected to client: ('10.142.105.6', 53580)
# Result calculated on server: 93


# Result calculated on server: 31


# Result calculated on server: 1176


# Result calculated on server: 28.0


# Result calculated on server: Error beacuase Division by zero


# Result calculated on server: Error beacuase Modulo by zero


# Result calculated on server: Invalid operator


# Result calculated on server: Invalid operator


# Exit command received. Server shutting down.