# TCP Client to send E-mail address and get validation result
# import socket

# def client_program():
#     host = socket.gethostname()  # same as server
#     port = 6000                  # same port

#     # Create TCP socket
#     client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
#     client_socket.connect((host, port))
#     print(f"Connected to TCP Server at {host}:{port}")
#     print("Type 'exit' to close the connection.\n")

#     while True:
#         email = input("Enter an email address: ")
#         client_socket.send(email.encode())

#         if email.lower().strip() == "exit":
#             print("Client shutting down.")
#             break

#         result = client_socket.recv(1024).decode()
#         print("Server Response:", result, "\n")

#     client_socket.close()

# if __name__ == '__main__':
#     client_program()




# UDP Client to send E-mail address and get validation result

import socket

def client_program():
    host = socket.gethostname()  # same as server hostname
    port = 6000                  # same port number

    # Create UDP socket
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    print(f"Connected to UDP Server at {host}:{port}")
    print("Type 'exit' to close the connection.\n")

    while True:
        email = input("Enter an email address: ").strip()
        client_socket.sendto(email.encode(), (host, port))

        if email.lower() == "exit":
            print("Client shutting down.")
            break

        # Receive result from server
        data, _ = client_socket.recvfrom(1024)
        print("Server Response:", data.decode(), "\n")

    client_socket.close()

if __name__ == '__main__':
    client_program()


# Enter an email address: uk.gmail.com
# Server Response: 'uk.gmail.com' is an INVALID Gmail address 

# Enter an email address: uk@..gmail.com
# Server Response: 'uk@..gmail.com' is an INVALID Gmail address  

# Enter an email address: exit
# Client shutting down.