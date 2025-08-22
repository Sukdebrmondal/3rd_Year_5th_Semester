import socket


def client_program():
    host = socket.gethostname()  
    port = 5000  # socket server port number

    # creates client side socket
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)  # creates client side socket
    client_socket.connect((host, port))  # connects to the server

    # message = input(" -> ")  # takes input

    # while message.lower().strip() != 'bye':
    #     client_socket.send(message.encode())  # sends message
    #     data = client_socket.recv(1024).decode()  # receives response

    #     print('Received from server: ' + data)  

    #     message = input(" -> ")  

    while True:

        print("\nenter the numbera: ")
        a = input("enter first number: ")
        if a == "exit":
            break
        b = input("enter second number: ")
        c = input("enter the operator")

        message = f"{a},{b},{c}"
        client_socket.send(message.encode())

        data = client_socket.recv(1024).decode()

        print(data)




    client_socket.close()  # closes the connection


if __name__ == '__main__':
    client_program()
