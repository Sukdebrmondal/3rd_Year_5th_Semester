import socket

def client_program():
    host=socket.gethostname()
    port=5000

    client_socket=socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    client_socket.connect((host,port))
    
    filename = input("Enter the filename to request: ")
    block_size = input("Enter block size (number of bytes): ")

    message=f"{filename}{block_size}"
    client_socket.send(message.encode())


if __name__ == "__main__":
    client_program()