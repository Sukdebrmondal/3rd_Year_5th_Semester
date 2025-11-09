# TCP Client to send MAC address and get validation result
import socket

def client_program():
    host = socket.gethostname()   # same as server
    port = 6000                   # same port

    # Create TCP socket
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client_socket.connect((host, port))

    print(f"Connected to TCP Server at {host}:{port}")
    print("Type 'exit' to close the connection.\n")

    while True:
        mac = input("Enter a MAC address: ")
        client_socket.send(mac.encode())

        if mac.lower().strip() == "exit":
            print("Client shutting down.")
            break

        data = client_socket.recv(1024).decode()
        print("Server response:", data)
        print()

    client_socket.close()

if __name__ == '__main__':
    client_program()



# UDP Client to send MAC address and get validation result
import socket

def client_program():
    host = socket.gethostname()   # same as server
    port = 6000                   # same port

    # Create UDP socket
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    print(f"Connected to UDP Server at {host}:{port}")
    print("Type 'exit' to close the connection.\n")

    while True:
        mac = input("Enter a MAC address: ")
        client_socket.sendto(mac.encode(), (host, port))

        if mac.lower().strip() == "exit":
            print("Client shutting down.")
            break

        data, server_addr = client_socket.recvfrom(1024)
        print("Server response:", data.decode())
        print()

    client_socket.close()

if __name__ == '__main__':
    client_program()


# Connected to UDP Server at SUKDEB:6000
# Type 'exit' to close the connection.

# Enter a MAC address: 00:1A:2B:3C:4D:5E
# Server response: '00:1A:2B:3C:4D:5E' is a VALID MAC address.

# Enter a MAC address: GG:HH:II:JJ:KK:LL
# Server response: 'GG:HH:II:JJ:KK:LL' is an INVALID MAC address.

# Enter a MAC address: exit
# Client shutting down.
