# TCP
# import socket

# def client_program():
#     host = socket.gethostname()
#     port = 5000
#     address = (host,port)

#     client_socket = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
#     client_socket.connect(address)
#     print("Tcp client start..........")

#     n = input("Enter a number: ")
#     client_socket.send(n.encode())

#     data = client_socket.recv(1024).decode()
#     print("client side result: ",data)

# if __name__ == "__main__":
#     client_program()





# UDP
import socket

def client_program():
    host = socket.gethostname()
    port = 5000
    address = (host,port)

    client_socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
    
    print("UDP client start..........")
    
    n = input("Enter a port number: ")
    client_socket.sendto(n.encode(),address)

    data, address = client_socket.recvfrom(1024)
    data = data.decode()
    print("client side result: ",data)

if __name__ == "__main__":
    client_program()