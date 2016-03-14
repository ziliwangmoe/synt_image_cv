clear all;
oriImg =imread('Screenshot_2.png');
width = size(oriImg, 2);
height = size(oriImg, 1);
points3DData = csvread('pointsData.csv');
nn=0;

for i=1:width
    for j=1:height
        if(oriImg(j,i,1)>0)
            colorInd = ceil(oriImg(j,i,1)/10.0);
            points3D(colorInd,:) = points3DData(colorInd,:);
            points2D(colorInd,:) = [i j];
            nn=nn+1;
            points1(nn,:)=[i j];
            pointVal(nn) = oriImg(j,i,1);
        end
    end
end
figure;

%plot(pointVal,'.');

imshow('Screenshot_3.png');
hold on
for i=1:size(points1,1)
    pt= points1(i,:);
    plot(pt(1),pt(2),'r.');
end