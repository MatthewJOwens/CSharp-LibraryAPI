-- CREATE TABLE books (
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(80) NOT NULL,
--   author VARCHAR(80) NOT NULL,
--   description VARCHAR(255),
--   available TINYINT NOT NULL,
--   PRIMARY KEY (id)
-- )
-- CREATE TABLE tags (
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR(20) NOT NULL,
--   PRIMARY KEY (id)
-- )
CREATE TABLE tagbooks(
  id INT NOT NULL AUTO_INCREMENT,
  bookId INT NOT NULL,
  tagId INT NOT NULL,
  PRIMARY KEY (id),
  INDEX (bookId),
  FOREIGN KEY (bookId)
    REFERENCES books (id)
    ON DELETE CASCADE,

  FOREIGN KEY (tagId)
    REFERENCES tags (id)
    ON DELETE CASCADE
)
-- SELECT * FROM books WHERE Id = 1
