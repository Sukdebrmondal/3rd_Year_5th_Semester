# TCP Client to send a port number and get validation result
import socket

def client_program():
    host = socket.gethostname()  # same as server hostname
    port = 6000                  # same port as server

    # Create TCP socket
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client_socket.connect((host, port))
    print(f"Connected to TCP Server at {host}:{port}")
    print("Type 'exit' to close the connection.\n")

    while True:
        port_num = input("Enter a port number: ")
        client_socket.send(port_num.encode())

        if port_num.lower().strip() == "exit":
            print("Client shutting down.")
            break

        # Receive validation result
        data = client_socket.recv(1024).decode()
        print("Server response:", data)
        print()

    client_socket.close()

if __name__ == '__main__':
    client_program()


# uDP
# UDP Client to send a port number and get validation result
# import socket

# def client_program():
#     host = socket.gethostname()   # same as server hostname
#     port = 6000                   # same port as server

#     # Create UDP socket
#     client_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
#     server_address = (host, port)

#     print(f"Connected to UDP Server at {host}:{port}")
#     print("Type 'exit' to close the connection.\n")

#     while True:
#         port_num = input("Enter a port number: ")

#         # Send port number to server
#         client_socket.sendto(port_num.encode(), server_address)

#         if port_num.lower().strip() == "exit":
#             print("Client shutting down.")
#             break

#         # Receive response from server
#         data, _ = client_socket.recvfrom(1024)
#         print("Server response:", data.decode())
#         print()

#     client_socket.close()

# if __name__ == '__main__':
#     client_program()



# Connected to UDP Server at SUKDEB:6000
# Type 'exit' to close the connection.

# Enter a port number: 8080
# Server response: '8080' is a VALID port number.

# Enter a port number: 70000
# Server response: '70000' is an INVALID port number.

# Enter a port number: exit
# Client shutting down.
