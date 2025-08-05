import socket


def server_program():
    
    host = socket.gethostname()
    port = 6000  
    
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)  

    server_socket.bind((host, port))  

    print("UDP Server Running: ")
    while True:
       
        data, address = server_socket.recvfrom(1024)
        
        if not data:
       
            break
        print("from connected user: " + data.decode())
       
        data = input(' -> ')
        server_socket.sendto(data.encode(),address)

    server_socket.close()

if __name__ == '__main__':
    server_program()
