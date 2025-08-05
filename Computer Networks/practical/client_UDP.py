import socket


def client_program():
    host = socket.gethostname()  
    port = 6000  
    serveraddress = (host,port)
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)  
   

    message = input(" -> ") 

    while message.lower().strip() != 'bye':
        client_socket.sendto(message.encode(),serveraddress)  
        data, address = client_socket.recvfrom(1024)  

        print('Received from server: ' + data.decode())  

        message = input(" -> ")  

    client_socket.close()

if __name__ == '__main__':
    client_program()
