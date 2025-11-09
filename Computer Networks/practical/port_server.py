# TCP Server to check if a port number is valid or not
import socket

def server_program():
    host = socket.gethostname()   # local hostname
    port = 6000                   # port number (for communication)

    # Create TCP socket
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

    # Bind host and port
    server_socket.bind((host, port))

    # Start listening for connections
    server_socket.listen(1)
    print(f"TCP Server is running on {host}:{port} ...")

    # Accept client connection
    conn, address = server_socket.accept()
    print(f"Connection established with client: {address}")

    while True:
        # Receive port number from client
        data = conn.recv(1024).decode()
        if not data:
            break
        if data.lower().strip() == "exit":
            print("Server shutting down.")
            break

        print(f"Received Port Number from client: {data}")

        # --------------------------
        # Check Port Validity (inside while loop)
        # --------------------------
        if data.isdigit():
            port_num = int(data)
            if 0 <= port_num <= 65535:
                valid = True
            else:
                valid = False
        else:
            valid = False

        # Prepare result message
        if valid:
            result = f"'{data}' is a VALID port number."
        else:
            result = f"'{data}' is an INVALID port number."

        # Show result on server
        print("Result:", result)

        # Send result back to client
        conn.send(result.encode())

    conn.close()
    server_socket.close()

if __name__ == '__main__':
    server_program()


# UDP
# UDP Server to check if a port number is valid or not
# import socket

# def server_program():
#     host = socket.gethostname()   # local hostname
#     port = 6000                   # port number (for communication)

#     # Create UDP socket
#     server_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
#     server_socket.bind((host, port))

#     print(f"UDP Server is running on {host}:{port} ...")

#     while True:
#         # Receive port number and client address
#         data, address = server_socket.recvfrom(1024)
#         data = data.decode()

#         if data.lower().strip() == "exit":
#             print("Server shutting down.")
#             break

#         print(f"Received Port Number from client {address}: {data}")

#         if data.isdigit():
#             port_num = int(data)
#             if 0 <= port_num <= 65535:
#                 valid = True
#             else:
#                 valid = False
#         else:
#             valid = False

#         # Prepare result message
#         if valid:
#             result = f"'{data}' is a VALID port number."
#         else:
#             result = f"'{data}' is an INVALID port number."

#         # Show result on server
#         print("Result:", result)

#         # Send result back to client
#         server_socket.sendto(result.encode(), address)

#     server_socket.close()

# if __name__ == '__main__':
#     server_program()


# UDP Server is running on SUKDEB:6000 ...
# Received Port Number from client ('10.142.105.6', 54000): 8080
# Result: '8080' is a VALID port number.
# Received Port Number from client ('10.142.105.6', 54000): 70000
# Result: '70000' is an INVALID port number.
# Server shutting down.
