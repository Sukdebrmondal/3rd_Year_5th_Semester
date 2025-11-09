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

    # Receive data (email list) from client
    data = conn.recv(4096).decode()
    emails = data.strip().split('\n')

    # Regular expression for valid Gmail addresses
    pattern = r'^[a-zA-Z0-9._%+-]+@gmail\.com$'

    valid_emails = []
    invalid_emails = []

    for email in emails:
        email = email.strip()
        if not email:
            continue
        if re.match(pattern, email):
            valid_emails.append(email)
        else:
            invalid_emails.append(email)

    # Print result on server side
    print("\nEmail Validation Summary:")
    print("Valid Emails:")
    for e in valid_emails:
        print("   ", e)
    print("Invalid Emails:")
    for e in invalid_emails:
        print("   ", e)

    valid_count = len(valid_emails)
    invalid_count = len(invalid_emails)

    print(f"\nTotal Valid Emails  : {valid_count}")
    print(f"Total Invalid Emails: {invalid_count}")

    
    result = (
        f"Valid Emails ({valid_count}):\n" +
        "\n".join(valid_emails) +
        f"\n\nInvalid Emails ({invalid_count}):\n" +
        "\n".join(invalid_emails)
    )

    conn.send(result.encode())

    conn.close()
    server_socket.close()

if __name__ == '__main__':
    server_program()




# udp
# import socket
# import re

# def server_program():
#     host = socket.gethostname()   # local hostname
#     port = 6000                   # port number

#     # Create UDP socket
#     server_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
#     server_socket.bind((host, port))

#     print(f"UDP Server is running on {host}:{port} ...")

#     # Receive data (email list) from client
#     data, address = server_socket.recvfrom(4096)
#     emails = data.decode().strip().split('\n')

#     print(f"Connection established with client: {address}")

#     # Regular expression for valid Gmail addresses
#     pattern = r'^[a-zA-Z0-9._%+-]+@gmail\.com$'

#     valid_emails = []
#     invalid_emails = []

#     for email in emails:
#         email = email.strip()
#         if not email:
#             continue
#         if re.match(pattern, email):
#             valid_emails.append(email)
#         else:
#             invalid_emails.append(email)

#     # Print result on server side
#     print("\nEmail Validation Summary:")
#     print("Valid Emails:")
#     for e in valid_emails:
#         print("   ", e)
#     print("Invalid Emails:")
#     for e in invalid_emails:
#         print("   ", e)

#     valid_count = len(valid_emails)
#     invalid_count = len(invalid_emails)

#     print(f"\nTotal Valid Emails  : {valid_count}")
#     print(f"Total Invalid Emails: {invalid_count}")

#     # Send result back to client
#     result = (
#         f"Valid Emails ({valid_count}):\n" +
#         "\n".join(valid_emails) +
#         f"\n\nInvalid Emails ({invalid_count}):\n" +
#         "\n".join(invalid_emails)
#     )

#     server_socket.sendto(result.encode(), address)
#     server_socket.close()

# if __name__ == '__main__':
#     server_program()

