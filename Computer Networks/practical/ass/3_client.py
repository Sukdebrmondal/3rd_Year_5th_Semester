import socket



def client_program():
    host = socket.gethostname() #local host
    port = 5000
    serveraddress = (host,port)
    print(host)
    print(serveraddress)
    #  create socket
    client_socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
    # takes input
    while True:

        a = input("write the filename: ")
            

        message = a   #Combine into one string
            
        client_socket.sendto(message.encode(),serveraddress) #sends the data
        if a.lower().strip() == "exit":  # notify server to stop
            print("Client exiting...")
            break
        data, address = client_socket.recvfrom(1024) #receive the data
                
        print("Receive the answer from the server: ", data.decode()) #print the result
            
    client_socket.close()

if __name__ == '__main__':
    client_program()