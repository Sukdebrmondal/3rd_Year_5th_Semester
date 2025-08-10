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
    principal = input("write the amount: ")
    rate = input("write the rate: ")
    time = input("write the time: ")

    message = principal + " " + rate + " " + time #Combine into one string
    
    client_socket.sendto(message.encode(),serveraddress) #sends the data
    data, address = client_socket.recvfrom(1024) #receive the data
        
    print("Receive the answer from the server: ", data.decode()) #print the result
        
    client_socket.close()

if __name__ == '__main__':
    client_program()