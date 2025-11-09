# TCP Server to check if a MAC address is valid or not
import socket
import re

def server_program():
    host = socket.gethostname()   # local hostname
    port = 6000                   # port number

    # Create TCP socket
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind((host, port))
    server_socket.listen(1)

    print(f"TCP Server is running on {host}:{port} ...")

    # Accept client connection
    conn, address = server_socket.accept()
    print(f"Connection established with client: {address}")

    while True:
        # Receive MAC address from client
        data = conn.recv(1024).decode()
        if not data:
            break
        if data.lower().strip() == "exit":
            print("Server shutting down.")
            break

        print(f"Received MAC from client: {data}")

        pattern = r"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$"

        if re.match(pattern, data.strip()):
            result = f"'{data}' is a VALID MAC address."
        else:
            result = f"'{data}' is an INVALID MAC address."

        # Show result on server
        print("Result:", result)

        # Send result back to client
        conn.send(result.encode())

    conn.close()
    server_socket.close()

if __name__ == '__main__':
    server_program()



# UDP Server to check if a MAC address is valid or not
import socket
import re

def server_program():
    host = socket.gethostname()   # local hostname
    port = 6000                   # port number

    # Create UDP socket
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    server_socket.bind((host, port))

    print(f"UDP Server is running on {host}:{port} ...")

    while True:
        # Receive MAC address from client
        data, address = server_socket.recvfrom(1024)
        data = data.decode()

        if data.lower().strip() == "exit":
            print("Server shutting down.")
            break

        print(f"Received MAC from client {address}: {data}")

        
        pattern = r"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$"

        if re.match(pattern, data.strip()):
            result = f"'{data}' is a VALID MAC address."
        else:
            result = f"'{data}' is an INVALID MAC address."

        # Show result on server
        print("Result:", result)

        # Send result back to client
        server_socket.sendto(result.encode(), address)

    server_socket.close()

if __name__ == '__main__':
    server_program()


# UDP Server is running on SUKDEB:6000 ...
# Received MAC from client ('10.142.105.6', 51000): 00:1A:2B:3C:4D:5E
# Result: '00:1A:2B:3C:4D:5E' is a VALID MAC address.
