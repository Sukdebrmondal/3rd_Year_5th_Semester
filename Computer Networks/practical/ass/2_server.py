# import socket

# def server_program():
#     host = socket.gethostname() #local host
#     port = 5000
#     print("->" + host)

#     # socket create
#     server_socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)

#     # connection
#     server_socket.bind((host, port))
#     print("UDP Server running.....")

#     while True:
#         data,address = server_socket.recvfrom(1024)
#         print("data: ", data)
#         print("Address: ", address)
#         message = data.decode()
#         if message.lower().strip() == "exit":
#             print("Server shutting down.")
#             break
#         a=int(message)
#         b=abs(a)
#         s = 0
#         num=str(b)
#         for i in range(1,len(num)):  
#             if (i+1)%2==0:
#                 s=s+int(num[i])
#         print(s)
        
#         #convert into string
#         result = str(s)
#         #send the result to the client
#         print("the output is: ",result)
#         server_socket.sendto(result.encode(),address)
        
#     server_socket.close()


# if __name__ == '__main__':
#     server_program()


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

