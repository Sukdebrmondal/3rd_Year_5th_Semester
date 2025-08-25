# import socket



# def client_program():
#     host = socket.gethostname() #local host
#     port = 5000
#     serveraddress = (host,port)
#     print(host)
#     print(serveraddress)
#     #  create socket
#     client_socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
#     print("UDP Client running.....")
#     # takes input
#     while True:

#         a = input("write the number: ")
#         if a.lower().strip()=="exit":
#             print("Client shutting down.")
#             break
#         message = a   #Combine into one string        
#         client_socket.sendto(message.encode(),serveraddress) #sends the data
#         if a.lower().strip() == "exit":  # notify server to stop
#             print("Client exiting...")
#             break
#         data, address = client_socket.recvfrom(1024) #receive the data           
#         print("Receive the answer from the server: ", data.decode()) #print the result
            
#     client_socket.close()

# if __name__ == '__main__':
#     client_program()

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