# # TCP Server to check if an IP address is valid or not 
import socket

def client_program():
    host = socket.gethostname()
    port = 6000

    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client_socket.connect((host, port))
    print(f"Connected to TCP Server at {host}:{port}")
    print("Type 'exit' to close the connection.\n")

    while True:
        ip = input("Enter an IP address: ")
        client_socket.send(ip.encode())

        if ip.lower().strip() == "exit":
            print("Client shutting down.")
            break

        data = client_socket.recv(1024).decode()
        print("Server response:", data)
        print()

    client_socket.close()

if __name__ == '__main__':
    client_program()



# Below UDP
# UDP Client to send an IP address and get validation result
# import socket

# def client_program():
#     host = socket.gethostname()   # same hostname as server
#     port = 6000                   # same port as server

#     # Create UDP socket
#     client_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
#     server_address = (host, port)

#     print(f"Connected to UDP Server at {host}:{port}")
#     print("Type 'exit' to close the connection.\n")

#     while True:
#         ip = input("Enter an IP address: ")

#         # Send IP address to server
#         client_socket.sendto(ip.encode(), server_address)

#         if ip.lower().strip() == "exit":
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

# Enter an IP address: 192.168.1.1
# Server response: '192.168.1.1' is a VALID IP address.

# Enter an IP address: 300.10.1.5
# Server response: '300.10.1.5' is an INVALID IP address.

# Enter an IP address: exit
# Client shutting down.
