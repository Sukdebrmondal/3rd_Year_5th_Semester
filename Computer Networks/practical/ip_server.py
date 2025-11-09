# TCP Server to check if an IP address is valid or not
import socket

def server_program():
    host = socket.gethostname()   # local hostname
    port = 6000                   # port number

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
        # Receive IP address from client
        data = conn.recv(1024).decode()
        if not data:
            break
        if data.lower().strip() == "exit":
            print("Server shutting down.")
            break

        print(f"Received IP from client: {data}")

        parts = data.split('.')
        if len(parts) == 4:
            valid = True
            for part in parts:
                if not part.isdigit() or int(part) < 0 or int(part) > 255:
                    valid = False
                    break
        else:
            valid = False

        # Prepare result message
        if valid:
            result = f"'{data}' is a VALID IP address."
        else:
            result = f"'{data}' is an INVALID IP address."

        # Show result on server
        print("Result:", result)

        # Send result back to client
        conn.send(result.encode())

    conn.close()
    server_socket.close()

if __name__ == '__main__':
    server_program()




# Below UDp
# UDP Server to check if an IP address is valid or not
# import socket

# def server_program():
#     host = socket.gethostname()   # local hostname
#     port = 6000                   # port number

#     # Create UDP socket
#     server_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
#     server_socket.bind((host, port))

#     print(f"UDP Server is running on {host}:{port} ...")

#     while True:
#         # Receive IP address and client address
#         data, address = server_socket.recvfrom(1024)
#         data = data.decode()

#         if data.lower().strip() == "exit":
#             print("Server shutting down.")
#             break

#         print(f"Received IP from client {address}: {data}")

        
#         parts = data.split('.')
#         if len(parts) == 4:
#             valid = True
#             for part in parts:
#                 if not part.isdigit() or int(part) < 0 or int(part) > 255:
#                     valid = False
#                     break
#         else:
#             valid = False

#         # Prepare result message
#         if valid:
#             result = f"'{data}' is a VALID IP address."
#         else:
#             result = f"'{data}' is an INVALID IP address."

#         # Show result on server
#         print("Result:", result)

#         # Send result back to client
#         server_socket.sendto(result.encode(), address)

#     server_socket.close()

# if __name__ == '__main__':
#     server_program()


# UDP Server is running on SUKDEB:6000 ...
# Received IP from client ('10.142.105.6', 53988): 192.168.1.1
# Result: '192.168.1.1' is a VALID IP address.
# Received IP from client ('10.142.105.6', 53988): 300.10.1.5
# Result: '300.10.1.5' is an INVALID IP address.
# Server shutting down.
