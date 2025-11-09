# Develop a client-Server application using UDP where the client will send a decimal integer 
# to the server and the server will calculate the sum of its even positioned digits and send back 
# the result to the client. The client will display the result. [Example: Input: 1248, Output: 
# 2+8=10] 

import socket   

def server_program():
    # Get the hostname of the machine 
    host = socket.gethostname()  # local host
    port = 5000                  # Port number 
    print("->" + host)

    # Create a UDP socket 
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

    # Bind the socket with the host and port 
    server_socket.bind((host, port))
    print("UDP Server running.....")

    
    while True:
        # Receive data from client
        data, address = server_socket.recvfrom(1024)

        # Print the data received from client
        print("data: ", data)

        # Print the address of the client
        print("Address: ", address)

        # Decode the data into string
        message = data.decode()

        if message.lower().strip() == "exit":
            print("Server shutting down.")
            break

        # Convert received message into integer
        a = int(message)

        # Take absolute value 
        b = abs(a)
        s = 0
        # Convert number into string
        num = str(b)
        for i in range(1, len(num)):  
            if (i + 1) % 2 == 0:
                s = s + int(num[i])
        print(s)

        # Convert result into string 
        result = str(s)

        # Print the output 
        print("The output is: ", result)
        print("\n")
        # Send the result back to the client
        server_socket.sendto(result.encode(), address)

    # Close the server 
    server_socket.close()

if __name__ == '__main__':
    server_program()




# TCP
# import socket

# def server_program():
#     # Get the hostname of the machine 
#     host = socket.gethostname()   # local host
#     port = 5000                   # Port number 
#     print("-> " + host)

#     # Create a TCP socket
#     server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

#     # Bind socket with host and port
#     server_socket.bind((host, port))

#     # Start listening for connection (max 1 client)
#     server_socket.listen(1)
#     print("TCP Server running.....")

#     # Accept connection from client
#     conn, address = server_socket.accept()
#     print(f"Connection established with client: {address}\n")

#     while True:
#         # Receive data from client
#         data = conn.recv(1024).decode()

#         if not data:
#             break

#         print("Received data:", data)

#         if data.lower().strip() == "exit":
#             print("Server shutting down.")
#             break

#         try:
#             # Convert received message into integer
#             a = int(data)
#         except ValueError:
#             conn.send("Invalid input! Please enter a number.".encode())
#             continue

#         # Take absolute value 
#         b = abs(a)
#         s = 0
#         # Convert number into string
#         num = str(b)
#         for i in range(len(num)):
#             if (i + 1) % 2 == 0:   # even positioned digits
#                 s += int(num[i])

#         print("Sum of even-positioned digits:", s, "\n")

#         # Convert result into string and send back to client
#         result = str(s)
#         conn.send(result.encode())

#     # Close the connection and socket
#     conn.close()
#     server_socket.close()

# if __name__ == '__main__':
#     server_program()





















# PS E:\repositary\3rd_Year_5th_Semester\Computer Networks\practical\ass> python .\2_server.py
# ->SUKDEB
# UDP Server running.....
# data:  b'1248'
# Address:  ('10.142.105.6', 53417)
# 10
# The output is:  10


# data:  b'-581'
# Address:  ('10.142.105.6', 53417)
# 8
# The output is:  8


# data:  b'4321'
# Address:  ('10.142.105.6', 53417)
# 4
# The output is:  4


# data:  b'exit'
# Address:  ('10.142.105.6', 53417)
# Server shutting down.

