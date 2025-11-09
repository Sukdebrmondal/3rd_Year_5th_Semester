import socket

def client_program():
    host = socket.gethostname()   # same host as server
    port = 6000                   # same port as server

    # Create TCP socket
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client_socket.connect((host, port))
    print(f"Connected to TCP Server at {host}:{port}")

    # Ask user for filename
    filename = input("Enter the email file name (e.g., emails.txt): ")

    try:
        with open(filename, 'r') as file:
            data = file.read()
    except FileNotFoundError:
        print(f"Error: File '{filename}' not found!")
        client_socket.close()
        return

    # Send file content to server
    client_socket.send(data.encode())

    # Receive and print result from server
    result = client_socket.recv(8192).decode()
    print("\nServer Response:\n")
    print(result)

    client_socket.close()

if __name__ == '__main__':
    client_program()




# udp
# import socket

# def client_program():
#     host = socket.gethostname()   # same host as server
#     port = 6000                   # same port as server

#     # Create UDP socket
#     client_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

#     print(f"Connected to UDP Server at {host}:{port}")

#     # Ask user for filename
#     filename = input("Enter the email file name (e.g., emails.txt): ")

#     try:
#         with open(filename, 'r') as file:
#             data = file.read()
#     except FileNotFoundError:
#         print(f"Error: File '{filename}' not found!")
#         client_socket.close()
#         return

#     # Send file content to server
#     client_socket.sendto(data.encode(), (host, port))

#     # Receive result from server
#     result, _ = client_socket.recvfrom(8192)
#     print("\nServer Response:\n")
#     print(result.decode())

#     client_socket.close()

# if __name__ == '__main__':
#     client_program()
