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
        

        
        a,b,c=map(str,message.split(",")) # Extract values

        # convert to float value
        principal= float(a)
        rate = float(b)
        time = float(c)

        print("principal: ", principal)
        print("Rate: ", rate)
        print("Time: ", time)

        #calculate the interest
        result = (principal * rate * time)/100
        print(result)
        #convert into string
        interest = str(result)
        #send the result to the client
        print("the interest is: ",interest)
        server_socket.sendto(interest.encode(),address)
        
    server_socket.close()


if __name__ == '__main__':
    server_program()