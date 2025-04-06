CREATE TABLE ClientsModel (
client_id INT PRIMARY KEY IDENTITY,
first_name VARCHAR (255) NOT NULL,
last_name VARCHAR (255) NOT NULL,
middle_name VARCHAR (255) NOT NULL,
age INT NOT NULL,
address VARCHAR (255) NOT NULL,
gender VARCHAR (255) NOT NULL,
created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE WalletsModel (
client_id INT NOT NULL,
wallet_id INT PRIMARY KEY IDENTITY,
balance DEC(38, 2) NOT NULL,
status VARCHAR(255) NOT NULL CHECK (status IN('Loaned', 'Default')),
loaned DEC(38, 2) NOT NULL,
created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
FOREIGN KEY (client_id) REFERENCES ClientsModel(client_id)
);

CREATE TABLE RFIDModel (
	key_index INT PRIMARY KEY IDENTITY,
	client_id INT NOT NULL,
	rfid VARCHAR (255),
	created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (client_id) REFERENCES ClientsModel(client_id)
)

CREATE TABLE SessionModel (
    session_id INT PRIMARY KEY IDENTITY,
	rfid VARCHAR (255) NOT NULL UNIQUE,
	pick_up VARCHAR (255) NOT NULL,
	drop_off VARCHAR (255) DEFAULT 'N/A'
);
