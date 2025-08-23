import socket

def server_program():
    host = socket.gethostname() #local host
    port = 5000
    print("->" + host)

    # socket create
    server_socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)

    # connection
    server_socket.bind((host, port))
    print("UDP Server running.....")

    while True:
        data,address = server_socket.recvfrom(1024)
        print("data: ", data)
        print("Address: ", address)
        message = data.decode()
        if message.lower().strip() == "exit":
            print("Server shutting down.")
            break
        a=int(message)
        b=abs(a)
        s = 0
        num=str(b)
        for i in range(1,len(num)):  
            if (i+1)%2==0:
                s=s+int(num[i])
        print(s)
        
        #convert into string
        result = str(s)
        #send the result to the client
        print("the output is: ",result)
        server_socket.sendto(result.encode(),address)
        
    server_socket.close()


if __name__ == '__main__':
    server_program()