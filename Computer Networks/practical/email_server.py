# TCP Server to check if an E-mail address is valid or not
# import socket
# import re

# def server_program():
#     host = socket.gethostname()   # local hostname
#     port = 6000                   # port number

#     # Create TCP socket
#     server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
#     server_socket.bind((host, port))
#     server_socket.listen(1)
#     print(f"TCP Server is running on {host}:{port} ...")

#     # Accept client connection
#     conn, address = server_socket.accept()
#     print(f"Connection established with client: {address}\n")

#     while True:
#         # Receive email from client
#         data = conn.recv(1024).decode()
#         if not data:
#             break
#         if data.lower().strip() == "exit":
#             print("Server shutting down.")
#             break

#         print(f"Received Email from client: {data}")

#         # Check if email is valid Gmail ID
        
#         pattern = r'^[a-zA-Z0-9._%+-]+@gmail\.com$'

#         if re.match(pattern, data):
#             result = f"'{data}' is a VALID Gmail address"
#         else:
#             result = f"'{data}' is an INVALID Gmail address"

#         # Show result on server
#         print("Result:", result, "\n")

#         # Send result back to client
#         conn.send(result.encode())

#     conn.close()
#     server_socket.close()

# if __name__ == '__main__':
#     server_program()



# UDP Server to check if an E-mail address is valid or not
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
        # Receive data from client
        data, client_address = server_socket.recvfrom(1024)
        email = data.decode().strip()

        if email.lower() == "exit":
            print("Server shutting down.")
            break

        print(f"Received Email from client: {email}")

        # -------------------------------
        # Check if email is valid Gmail ID
        # -------------------------------
        pattern = r'^[a-zA-Z0-9._%+-]+@gmail\.com$'

        if re.match(pattern, email):
            result = f"'{email}' is a VALID Gmail address"
        else:
            result = f"'{email}' is an INVALID Gmail address"

        # Show result on server
        print("Result:", result, "\n")

        # Send result back to client
        server_socket.sendto(result.encode(), client_address)

    server_socket.close()

if __name__ == '__main__':
    server_program()

# Received Email from client: uk.gmail.com
# Result: 'uk.gmail.com' is an INVALID Gmail address 

# Received Email from client: uk@..gmail.com
# Result: 'uk@..gmail.com' is an INVALID Gmail address 

# Server shutting down.