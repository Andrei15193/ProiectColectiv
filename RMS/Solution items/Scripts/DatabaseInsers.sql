insert into Members(type, name, email, password, teachingPosition, hasPhd, telephone, website, address, domainsOfInterest)
    values (2, 'Boian Florian', 'florin@cs.ubbcluj.ro', '123456', 3, 1, '5829', 'http://www.cs.ubbcluj.ro/~florin', 'Campus 304', 'Sisteme de operare, Programare concurenta si distribuita')

insert into Members(type, name, email, password, teachingPosition, hasPhd, telephone, website, address, domainsOfInterest)
    values (2, 'Czibula Gabriela', 'gabis@cs.ubbcluj.ro', '123456', 3, 1, '5815', 'http://www.cs.ubbcluj.ro/~gabis', 'Campus 440', 'Inteligenta artificiala, Limbaje de programare')
    
insert into Members(type, name, email, password, teachingPosition, hasPhd, telephone, website, address, domainsOfInterest)
    values (0, 'Director', 'director@director.ro', '123456', NULL, 0, NULL, NULL, NULL, NULL)

insert into Members(type, name, email, password, teachingPosition, hasPhd, telephone, website, address, domainsOfInterest)
    values (1, 'Admin', 'admin@admin.ro', '123456', NULL, 0, NULL, NULL, NULL, NULL)

select * from Members
