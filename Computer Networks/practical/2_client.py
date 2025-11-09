
import socket   

def client_program():
    # Get the hostname of the machine 
    host = socket.gethostname()   # local host
    # Define the same port as the server
    port = 5000
    #server address (host, port)
    serveraddress = (host, port)

    # Print host and address 
    print(host)
    print(serveraddress)

    # Create a UDP socket 
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    print("UDP Client running.....")

    while True:
        # Take input number from user
        a = input("Write the number: ")
        if a.lower().strip() == "exit":
            print("Client shutting down.")
            client_socket.sendto(a.encode(), serveraddress)
            break
        message = a

        # Send the number to the server
        client_socket.sendto(message.encode(), serveraddress)

        # Receive processed result
        data, address = client_socket.recvfrom(1024)

        # Print the result received from server
        print("Received the answer from the server: ", data.decode())
        print("\n")
    client_socket.close()

if __name__ == '__main__':
    client_program()





# TCP

# import socket

# def client_program():
#     # Get the hostname of the machine 
#     host = socket.gethostname()   # same host as server
#     port = 5000                   # same port as server

#     # Create a TCP socket
#     client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

#     # Connect to the server
#     client_socket.connect((host, port))
#     print(f"Connected to TCP Server at {host}:{port}")
#     print("Type 'exit' to stop.\n")

#     while True:
#         # Take input number from user
#         a = input("Write the number: ")

#         # Send message to server
#         client_socket.send(a.encode())

#         if a.lower().strip() == "exit":
#             print("Client shutting down.")
#             break

#         # Receive processed result
#         data = client_socket.recv(1024).decode()

#         # Print the result received from server
#         print("Received the answer from the server:", data)
#         print("\n")

#     client_socket.close()

# if __name__ == '__main__':
#     client_program()



# PS E:\repositary\3rd_Year_5th_Semester\Computer Networks\practical\ass> python .\2_client.py
# SUKDEB
# ('SUKDEB', 5000)
# UDP Client running.....
# Write the number: 1248
# Received the answer from the server:  10


# Write the number: -581
# Received the answer from the server:  8


# Write the number: 4321
# Received the answer from the server:  4


# Write the number: exit
# Client shutting down.